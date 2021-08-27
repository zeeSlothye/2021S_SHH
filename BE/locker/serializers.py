from django.db.models import fields
from rest_framework import serializers   #?
from .models import *
#FE MODEL이랑 완전히
class LockerSerializer(serializers.ModelSerializer):
    #JSON파일의 형태로 serialize해줌.
    class Meta:
        model = Locker
        fields = ['idx','type','number', 'stationName', 'stationLocation']

class OccupiedLockerSerializer(serializers.ModelSerializer):
    #JSON파일의 형태로 serialize해줌.
    class Meta:
        model = OccupiedLocker
        fields = ['idx',
        'lockerIdx', 'password', 
        'title', 'info', 
        'isOpen', 'date', 'trusterId', 'isPaid']
