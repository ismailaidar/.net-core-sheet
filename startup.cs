// global cors policy | allow external resourses to send requests to the server
  app.UseCors(x => x
      .AllowAnyMethod()
      .AllowAnyHeader()
      .SetIsOriginAllowed(origin => true) // allow any origin
      .AllowCredentials()); // allow credentials
