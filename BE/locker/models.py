from django.db import models
from django.utils import timezone
# Create your models here.
class Locker(models.Model):
    idx = models.AutoField(primary_key=True)

    type = models.IntegerField(null = False) # 순서대로 1 2 3 4 5 6 7 ..

    number = models.IntegerField(null = False)
    stationName = models.TextField(null = False, max_length=50)
    stationUUID = models.TextField()
    stationLocation = models.TextField(null = False, max_length=50)  # 비콘으로 하나? 어쩃든 있어야하기는 할듯

class OccupiedLocker(models.Model):
    idx = models.AutoField(primary_key=True)

    lockerIdx = models.IntegerField(null=False)
    password = models.TextField(null = False)

    title = models.TextField(null = False)
    info = models.TextField(null = True,blank=True)

    isOpen = models.BooleanField(null = False, default=False)

    date = models.DateField(null = False, default=timezone.now)#사용시작 시간

    trusterId = models.TextField(null = False)

    isPaid = models.BooleanField(null = False)