from django.db.models import fields
from rest_framework import serializers   #?
from .models import *
#FE MODEL이랑 완전히
class UserSerializer(serializers.ModelSerializer):
    #JSON파일의 형태로 serialize해줌.
    class Meta:
        model = User
        fields = ['phoneNumber','password', 'autoPayment']