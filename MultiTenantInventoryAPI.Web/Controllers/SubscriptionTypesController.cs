using Microsoft.AspNetCore.Mvc;
using MultiTenantInventoryAPI.Core.Aggregates.SubscriptionTypeAggregate;
using MultiTenantInventoryAPI.Core.Interfaces;
using MultiTenantInventoryAPI.UseCases.SubscriptionTypes;
using MultiTenantInventoryAPI.Web.SubscriptionTypes;

namespace MultiTenantInventoryAPI.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionTypesController : ControllerBase
{
    private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
    public SubscriptionTypesController(ISubscriptionTypeRepository subscriptionTypeRepository)
    {
        _subscriptionTypeRepository = subscriptionTypeRepository ??
            throw new ArgumentNullException(nameof(subscriptionTypeRepository));
    }

    // GET: api/SubscriptionTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionTypeRecord>>> GetSubcriptionTypes(CancellationToken cancellationToken = default)
    {
        var subscriptions = await _subscriptionTypeRepository.GetAllAsync(cancellationToken);
        var response = subscriptions.Select(s => new SubscriptionTypeRecord(
            s.Name.Value,
            s.FeeBase.Value,
            s.IsActive
        ));

        return Ok(response);
    }

    // GET: api/SubscriptionTypes/9
    [HttpGet("{id}")]
    public async Task<ActionResult<SubscriptionTypeRecord>> GetSubcriptionTypeById(SubscriptionTypeId id, CancellationToken cancellationToken = default)
    {
        var subscriptionType = await _subscriptionTypeRepository.GetByIdAsync(id, cancellationToken);

        if(subscriptionType == null)
        {
            return NotFound();
        }

        var subscriptionTypeRecord = new SubscriptionTypeRecord(
            subscriptionType.Name.Value,
            subscriptionType.FeeBase.Value,
            subscriptionType.IsActive);

        return Ok(subscriptionTypeRecord);
    }

    // POST: api/SubscriptionTypes
    [HttpPost]
    public async Task<ActionResult<SubscriptionTypeRecord>> PostSubscriptionType(SubscriptionTypeDTO subscriptionTypeDTO, CancellationToken cancellationToken)
    {
        var subscriptionType = new SubscriptionType(
            name: subscriptionTypeDTO.Name,
            feeBase: subscriptionTypeDTO.FeeBase,
            isActive: subscriptionTypeDTO.IsActive);

        _subscriptionTypeRepository.Add(subscriptionType);
        await _subscriptionTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var subscriptionTypeRecord = new SubscriptionTypeRecord(
            subscriptionType.Name.Value,
            subscriptionType.FeeBase.Value,
            subscriptionType.IsActive);

        return CreatedAtAction(
                nameof(GetSubcriptionTypeById),
                new { id = subscriptionType.Id.Value },
                subscriptionTypeRecord);
    }
}
