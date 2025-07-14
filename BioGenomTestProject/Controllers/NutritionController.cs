using BioGenomTestProject.DTOs;
using BioGenomTestProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BioGenomTestProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionController(INutritionService nutritionService) : ControllerBase
{
    private readonly INutritionService _nutritionService = nutritionService;

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<NutrientResultDto>>> GetNutritionAssessment()
    {
        var deficientNutrients = await _nutritionService.GetNutritionAssessmentAsync();
        return Ok(deficientNutrients);
    }

    [HttpGet("deficient")]
    public async Task<ActionResult<IEnumerable<NutrientResultDto>>> GetDeficientNutrients()
    {
        var deficientNutrients = await _nutritionService.GetDeficientNutrientsAsync();
        return Ok(deficientNutrients);
    }

    [HttpGet("sufficient")]
    public async Task<ActionResult<IEnumerable<NutrientResultDto>>> GetSufficientNutrients()
    {
        var sufficientNutrients = await _nutritionService.GetSufficientNutrientsAsync();
        return Ok(sufficientNutrients);
    }

    [HttpGet("summary")]
    public async Task<ActionResult<NutritionSummaryDto>> GetNutritionSummary()
    {
        var summary = await _nutritionService.GetNutritionSummaryAsync();
        return Ok(summary);
    }
} 