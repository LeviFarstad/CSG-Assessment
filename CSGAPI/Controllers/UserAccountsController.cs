using CSGAPI.Models;
using CSGAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly UserAccountsService _userAccountsService;

        public UserAccountsController(UserAccountsService userAccountsService)
        {
            _userAccountsService = userAccountsService;
        }
        
        [HttpGet]
        public ActionResult<UserAccounts> Get(UserAuthentication UserAuthenticationIn) {
            var userAccounts = _userAccountsService.Get(UserAuthenticationIn.id);
            
            if (userAccounts == null) {
                return Unauthorized();
            }

            return userAccounts;
        }

        [HttpPut]
        public ActionResult<UserBalanceUpdateResponse> Update( UserBalanceUpdate UserBalanceUpdateIn) {
            var userAccounts = _userAccountsService.Get(UserBalanceUpdateIn.id);
            var _userUpdateBalanceResponse = new UserBalanceUpdateResponse();
            _userUpdateBalanceResponse.Status = "0";
            _userUpdateBalanceResponse.StatusText = "Transaction Initialized";
            _userUpdateBalanceResponse.NewBalance = userAccounts.Balance;
            if (userAccounts == null) {
                //No Account found for ID
                _userUpdateBalanceResponse.Status = "404";
                _userUpdateBalanceResponse.StatusText = "No record found for supplied ID";
                return _userUpdateBalanceResponse;
            }
            if (UserBalanceUpdateIn.Amount < 0) {
                //Transaction amount cannot be negative
                _userUpdateBalanceResponse.Status = "400";
                _userUpdateBalanceResponse.StatusText = "Transaction account cannot be a negative number, use {'Type': 'Withdrawal'} with a positive number of the amount to withdraw";
                return _userUpdateBalanceResponse;
            }

            if (UserBalanceUpdateIn.Type.ToLower().Trim() == "withdrawal") {
                if (UserBalanceUpdateIn.Amount < userAccounts.WithdrawalLimit){
                    if (UserBalanceUpdateIn.Amount < userAccounts.Balance ) {
                        userAccounts.Balance -= UserBalanceUpdateIn.Amount;
                        _userAccountsService.Update(UserBalanceUpdateIn.id, userAccounts);
                        
                        _userUpdateBalanceResponse.Status = "200";
                        _userUpdateBalanceResponse.StatusText = "Withdrawal Processed";
                        _userUpdateBalanceResponse.NewBalance = userAccounts.Balance;
                    } else {
                        //Insufficient Funds
                        _userUpdateBalanceResponse.Status = "400";
                        _userUpdateBalanceResponse.StatusText = "Insufficient funds to process transaction";
                    }
                } else {
                    //Withdrawl Limit
                    _userUpdateBalanceResponse.Status = "400";
                    _userUpdateBalanceResponse.StatusText = "Amount requested is above withdrawal limit for account, please try again.";
                }
            } else if (UserBalanceUpdateIn.Type.ToLower().Trim() == "deposit") {
                userAccounts.Balance += UserBalanceUpdateIn.Amount;
                _userAccountsService.Update(UserBalanceUpdateIn.id, userAccounts);

                _userUpdateBalanceResponse.Status = "200";
                _userUpdateBalanceResponse.StatusText = "Deposit Accepted";
                _userUpdateBalanceResponse.NewBalance = userAccounts.Balance;
            } else {
                //Invalid Transaction Type
                _userUpdateBalanceResponse.Status = "400";
                _userUpdateBalanceResponse.StatusText = "Invalid Transaction Type. Use type of either 'Deposit' or 'Withdrawal'";
            }
            //Unknown Error
            return _userUpdateBalanceResponse;
        }
    }
}