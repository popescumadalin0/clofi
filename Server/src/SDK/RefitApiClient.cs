using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using SDK.Models;

namespace SDK;

public abstract class RefitApiClient<T> where T : class
{
    public event OnApiCallExecuted OnApiCallExecuted = _param1 => { };

    public async Task<ApiResponseMessage<T>> Execute<T>(Task<T> task)
    {
        try
        {
            T response = await task;
            this.OnApiCallExecuted(new ApiResponseMessage(true));
            return new ApiResponseMessage<T>(true, response);
        }
        catch (ApiException ex)
        {
            this.OnApiCallExecuted(new ApiResponseMessage(false, ex.StatusCode, ex.ReasonPhrase + " ; " + ex.Content));
            return new ApiResponseMessage<T>(false, Activator.CreateInstance<T>(), ex.StatusCode, ex.ReasonPhrase + " ; " + ex.Content);
        }
        catch (Exception ex)
        {
            this.OnApiCallExecuted(new ApiResponseMessage(false, HttpStatusCode.InternalServerError, "SDK Common : " + ex.Message));
            return new ApiResponseMessage<T>(false, Activator.CreateInstance<T>(), HttpStatusCode.InternalServerError, "SDK Common : " + ex.Message);
        }
    }

    public async Task<ApiResponseMessage> ExecuteWithNoContentResponse(
        Task task)
    {
        try
        {
            await task;
            this.OnApiCallExecuted(new ApiResponseMessage(true));
            return new ApiResponseMessage(true);
        }
        catch (ApiException ex)
        {
            this.OnApiCallExecuted(new ApiResponseMessage(false, ex.StatusCode, ex.ReasonPhrase + " ; " + ex.Content));
            return new ApiResponseMessage(false, ex.StatusCode, ex.ReasonPhrase + " ; " + ex.Content);
        }
        catch (Exception ex)
        {
            this.OnApiCallExecuted(new ApiResponseMessage(false, HttpStatusCode.InternalServerError, "SDK Common : " + ex.Message));
            return new ApiResponseMessage(false, HttpStatusCode.InternalServerError, "SDK Common : " + ex.Message);
        }
    }
}