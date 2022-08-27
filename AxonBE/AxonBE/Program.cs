using AxonBE.Dtos;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
app.UseAuthorization();

app.MapControllers();



var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    Console.WriteLine("aaaa");
    channel.QueueDeclare(queue: "events",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        dynamic obj = JsonConvert.DeserializeObject(message);
        if(obj.type == "OfficerGoesOnline")
        {
            OfficerOnline.Officers.Add(new Officer() { id = obj.officerId, badgeName = obj.badgeName });
        }
        Console.WriteLine(" [x] Received {0}", message);
    };
    channel.BasicConsume(queue: "events",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
}


app.Run("http://localhost:8001");