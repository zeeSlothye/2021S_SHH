from locker.models import Locker
from django.db.models import Q

from user.models import *
from django.http.response import HttpResponse
from rest_framework.response import Response
from rest_framework.decorators import api_view

from .serializers import *

## 가져오는..
@api_view(['POST'])
def create_user(request):
    User.objects.create(
        userId = request.data['userId'],
        userPw = request.data['userPw']
    )
    print("USER CREATED")


    
    ## 몹데이터를 만드는게 낫지 않을지? 중요한 부분이 아니라면
    # User.objects.create(
    #     userId = 'admin',
    #     userPw = '0000'
    # )
    # User.objects.create(
    #     userId = 'seller',
    #     userPw = '0000'
    # )
    # User.objects.create(
    #     userId = 'user',
    #     userPw = '0000'
    # )



    return HttpResponse("user created")
@api_view(['POST'])
def connect_user_beacon(request):
    # 모바일에서 UUID를 받은 경우 -> user의 UUID값을 변경시켜준다.
    # input
    # userId, UUID
    req = request.data
    userS = list(User.objects.filter(userId = req['userId']))
    user = userS[0]
    user.connectedUUID = req['UUID']
    user.save()
@api_view(['POST'])
def disconnect_user_beacon(request):
    # 모바일에서 UUID를 받은 경우 -> user의 UUID값을 변경시켜준다.
    # input
    # userId, UUID
    req = request.data
    userS = list(User.objects.filter(userId = req['userId']))
    user = userS[0]
    user.connectedUUID = ''
    user.save()
