using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ReviewGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }


        [HttpGet]
        [Route("generate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GenerateReview()
        {
            try
            {
                Review review = await _reviewService.GetReview();

                if (review == null)
                    return NotFound();

                return Ok(review);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {MethodBase.GetCurrentMethod()} threw exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("generate/{numberOfReviews}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GenerateReviews(int numberOfReviews)
        {
            try
            {
                if (numberOfReviews < 0)
                    throw new ArgumentException();

                List<Review> reviews = await _reviewService.GetReviews(numberOfReviews);

                if (reviews == null)
                    return NotFound();

                return Ok(reviews);
            }
            catch(ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Invalid input: {ex}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {MethodBase.GetCurrentMethod()} threw exception: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
