from .views import *
from django.urls import path,include
from django.contrib import admin

urlpatterns = [
    path('get_vacant_lockerS_stationIdx', get_vacant_lockerS_stationIdx),
    path('occupied/create', create_occupiedLocker),
    path('update_occupiedLocker', update_occupiedLocker)
]
