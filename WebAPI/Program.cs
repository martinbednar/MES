using BL.Daemons;
using BL.Mappers.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Uncomment the following line to enable communication with PLC (Opc UA server).
// builder.Services.AddHostedService<OpcUaClientDaemon>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoScrewingProcessDataProfile));
builder.Services.AddAutoMapper(typeof(ConductivityProcessDataProfile));
builder.Services.AddAutoMapper(typeof(FitAndFunctionMeasurementProfile));
builder.Services.AddAutoMapper(typeof(FitAndFunctionProcessDataProfile));
builder.Services.AddAutoMapper(typeof(ManualScrewingProcessDataProfile));
builder.Services.AddAutoMapper(typeof(NgAutoScrewingProcessDataProfile));
builder.Services.AddAutoMapper(typeof(PartAllProcessDataProfile));
builder.Services.AddAutoMapper(typeof(PressingProcessDataProfile));
builder.Services.AddAutoMapper(typeof(PressingReworkProcessDataProfile));
builder.Services.AddAutoMapper(typeof(ScanProcessDataProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
