using Amazon;
using Amazon.SQS;
using WorkingWithSqs.Publisher;
using WorkingWithSqs.Publisher.Messages;

var sqsClient = new AmazonSQSClient(RegionEndpoint.EUCentral1);

var publisher = new SqsPublisher(sqsClient);

await publisher.PublishAsync("customers", new CustomerCreated
{
    Id = 1,
    FullName = "BerkcTezc"
});

await Task.Delay(5000);

await publisher.PublishAsync("customers", new CustomerDeleted()
{
    Id = 1,
});