namespace PomeloMariaDbTest.Data.ReadModels.Test;

public class TestReadModel
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string Derp { get; set; }

    public TestReadModel(
        Guid id,
        Guid customerId,
        string derp)
    {
        Id = id;
        CustomerId = customerId;
        Derp = derp;
    }
}
