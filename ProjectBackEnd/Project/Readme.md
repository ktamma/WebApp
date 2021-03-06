#MVC web controllers

##Initial migration

~~~sh
dotnet ef migrations add --project App.Dal --startup-project WebApp Initial
~~~
~~~sh
dotnet ef database update --project App.Dal --startup-project WebApp
~~~
##MVC Web controllers
###Inside webapp
~~~sh
dotnet aspnet-codegenerator controller -name AllowedUsersController -actions -m App.Domain.AllowedUser -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name AnswerFilesController -actions -m App.Domain.AnswerFile -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CategoriesController -actions -m App.Domain.Category -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name FileTypesController -actions -m App.Domain.FileType -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name MaterialsController -actions -m App.Domain.Material -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name QuizzesController -actions -m App.Domain.Quiz -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name QuizAnswersController -actions -m App.Domain.QuizAnswer -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name QuizMaterialsController -actions -m App.Domain.QuizMaterial -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name QuizQuestionsController -actions -m App.Domain.QuizQuestion -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name QuizTypesController -actions -m App.Domain.QuizType -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TakesController -actions -m App.Domain.Take -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TakeAnswersController -actions -m App.Domain.TakeAnswer -dc ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
~~~

##Api controllers
###Inside webapp
~~~sh
dotnet aspnet-codegenerator controller -name AllowedUsersController -actions -m App.Domain.AllowedUser -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name AnswerFilesController -actions -m App.Domain.AnswerFile -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name CategoriesController -actions -m App.Domain.Category -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name FileTypesController -actions -m App.Domain.FileType -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name MaterialsController -actions -m App.Domain.Material -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name QuizzesController -actions -m App.Domain.Quiz -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name QuizAnswersController -actions -m App.Domain.QuizAnswer -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name QuizMaterialsController -actions -m App.Domain.QuizMaterial -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name QuizQuestionsController -actions -m App.Domain.QuizQuestion -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name QuizTypesController -actions -m App.Domain.QuizType -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name TakesController -actions -m App.Domain.Take -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
dotnet aspnet-codegenerator controller -name TakeAnswersController -actions -m App.Domain.TakeAnswer -dc ApplicationDbContext -outDir ApiControllers -api --useDefaultLayout --useAsyncActions -f
~~~
##Identity UI
###Inside webapp
~~~sh
dotnet aspnet-codegenerator identity -dc App.DAL.ApplicationDbContext -f
~~~



#   W e b A p p  
 