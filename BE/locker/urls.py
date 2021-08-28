from .views import *
from django.urls import path,include
from django.contrib import admin

urlpatterns = [
    path('occupied/get', get_occupiedLockerS_stationUUID),
    path('occupied/create', create_occupiedLocker),
    path('update_occupiedLocker', update_occupiedLocker)
]
