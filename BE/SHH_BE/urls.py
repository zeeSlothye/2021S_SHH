from django.urls import path,include
from django.contrib import admin

urlpatterns = [
    path('admin/', admin.site.urls),
    path('locker/', include('locker.urls')),
    path('user/', include('user.urls')),
]
