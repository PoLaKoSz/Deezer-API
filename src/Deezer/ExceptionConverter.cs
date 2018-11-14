using Newtonsoft.Json;
using PoLaKoSz.Deezer.Exceptions;
using PoLaKoSz.Deezer.Models;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer
{
    public class ExceptionConverter
    {
        private static readonly Dictionary<int, BaseException> _exceptionLists;



        static ExceptionConverter()
        {
            _exceptionLists = new Dictionary<int, BaseException>()
            {
                {   4, new QuotaException() },
                { 100, new ItemsLimitExceededException() },
                { 200, new MissingPermissionException() },
                { 300, new InvalidTokenException() },
                { 500, new InvalidParameterException() },
                { 501, new MissingParameterException() },
                { 600, new InvalidQueryException() },
                { 700, new BusyServiceException() },
                { 800, new DataNotFoundException() },
            };
        }



        /// <summary>
        /// Check if the response is an Exception and throw one if exists.
        /// </summary>
        /// <param name="stringResponse">Response from the Deezer server.</param>
        /// <returns>Unmodified server response.</returns>
        /// <exception cref="QuotaException">Too much API call sent in a time frame.</exception>
        /// <exception cref="ItemsLimitExceededException"></exception>
        /// <exception cref="MissingPermissionException">The API token hasn't got permission(s) which required for the operation.</exception>
        /// <exception cref="InvalidTokenException">The API token is invalid.</exception>
        /// <exception cref="InvalidParameterException">The passed parameter(s) contain(s) invalid values.</exception>
        /// <exception cref="MissingParameterException">Passed parameter not contains required parameters.</exception>
        /// <exception cref="InvalidQueryException">The requested query invalid.</exception>
        /// <exception cref="BusyServiceException">Deezer service busy.</exception>
        /// <exception cref="DataNotFoundException">Data not found on the server.</exception>
        /// <exception cref="InvalidCastException">An unknown Exception received from the server.</exception>
        public string ThrowExceptionOrContionue(string stringResponse)
        {
            var errorRoot = JsonConvert.DeserializeObject<ErrorRoot>(stringResponse);

            if (errorRoot != null && errorRoot.Error != null)
            {
                BaseException exception;

                try
                {
                    _exceptionLists.TryGetValue(errorRoot.Error.Code, out exception);
                    exception.Message = errorRoot.Error.Message;
                }
                catch (NullReferenceException)
                {
                    throw new InvalidCastException($"Unknow Exception returned from the Deezer server!\nServer response: {stringResponse}");
                }

                throw exception;
            }

            return stringResponse;
        }
    }
}
