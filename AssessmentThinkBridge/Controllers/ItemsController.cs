using AssessmentThinkBridge.Models;
using AssessmentThinkBridge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ItemsController : Controller
    {
        private ILogger _logger;

        //Here declare IItemsServices
        private readonly IItemsServices _iItemsServices;

        //Using parameter constructor assing Service object to interface.

        public ItemsController(ILogger<ItemsController> logger, IItemsServices iItemsServices)
        {
            _iItemsServices = iItemsServices;
            _logger = logger;
        }

        /// <summary>
        /// Get all list of items including Active and InActive records.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {
            try
            {
                var result = _iItemsServices.GetAllItems();

                if(result.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                //Log Exceptions
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");               
            }
        }

        /// <summary>
        /// Get item By Item ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetItemsByID/{ID}")]
        public IActionResult GetItemsByID(int ID)
        {
            try
            {
                var result = _iItemsServices.GetItems(ID);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Save and Update record. 
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPost("save")]
        public IActionResult Save(ItemModel itemModel)
        {

            try
            {
                var result = _iItemsServices.Save(itemModel);
               
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Delete Record
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("DeleteItem/{ID}")]
        public IActionResult DeleteItem(int ID)
        {
            try
            {
                var result= _iItemsServices.DeleteItem(ID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
