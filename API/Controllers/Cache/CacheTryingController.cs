using Business.Abstract.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers.Cache
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheTryingController : ControllerBase
    {

        private readonly ICache _cacheExample;

        public CacheTryingController(ICache cacheExample)
        {
            _cacheExample = cacheExample;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _cacheExample.DCSetString("TodebTestKey", "TodebTestValue");
            return Ok();
        }

        [HttpPost("SetList")]
        public IActionResult SetList()
        {
            _cacheExample.DCSetList("TodebTestKeyList");
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<string>();
            list.Add(_cacheExample.DCGetValue("TodebTestKey"));
            list.Add(_cacheExample.DCGetValue("TodebTestKeyList"));

            return Ok(list);
        }


        [HttpPost("InMemoryTest")]
        public IActionResult InMemoryTest()
        {
            _cacheExample.IMCSetString("InMemoryStr", "InMemoryStrExample");
            _cacheExample.IMCSetObject("InMemoryList", new int[] { 1, 2, 3, 6, 9 });
            return Ok();

        }

        [HttpGet("GetInMemory")]
        public IActionResult GetInMemory()
        {
            var strValue = _cacheExample.IMCGetValue<string>("InMemoryStr");
            var listValue = _cacheExample.IMCGetValue<int[]>("InMemoryList");

            return Ok(new { strValue, listValue });
        }

    }
}
