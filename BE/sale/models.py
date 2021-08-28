from django.db.models.fields import IntegerField
from locker.models import OccupiedLocker
from django.db import models

class Sale(models.Model):
    occupiedLockerIdx = models.IntegerField()

    #미세먼지, ... 각종 노출 조건들..
    