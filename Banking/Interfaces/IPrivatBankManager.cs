﻿using System;
using System.Threading.Tasks;
using Banking.Web.Dto;

namespace Banking.Web.Interfaces
{
    /// <summary>
    /// The privat bank manager interface.
    /// </summary>
    public interface IPrivatBankManager
    {
        /// <summary>
        /// Gets the session identifier.
        /// </summary>
        /// <returns>
        /// The session.
        /// </returns>
        Task<PBSessionDto> GetSessionAsync();

        /// <summary>
        /// Gets the person session.
        /// </summary>
        /// <param name="sessionID">The session identifier.</param>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The person session.
        /// </returns>
        Task<PBPersonSessionDto> GetPersonSessionAsync(string sessionID, string login, string password);

        Task<PBPersonSessionDto> SelectNumber(string sessionId, string numberId);

        /// <summary>
        /// Confirms the SMS code.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>The person session.</returns>
        Task<PBPersonSessionDto> ConfirmSmsCodeAsync(string sessionId, string code);

        /// <summary>
        /// Gets the statements.
        /// </summary>
        /// <param name="sessionID">The session identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="interestRate">The interest rate.</param>
        /// <returns></returns>
        Task<TaxesDto> GetTaxesAsync(string sessionID, DateTime startDate, DateTime endDate, double interestRate);
    }
}
