namespace PomeloMariaDbTest.Data.ReadModels.Test2;

public class Test2ReadModel
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string Derp { get; set; }

    public Test2ReadModel(
        Guid id,
        Guid customerId,
        string derp)
    {
        Id = id;
        CustomerId = customerId;
        Derp = derp;
    }
}
