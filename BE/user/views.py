from locker.models import Locker
from django.db.models import Q

from user.models import *
from django.http.response import HttpResponse
from rest_framework.response import Response
from rest_framework.decorators import api_view

from .serializers import *
import json
## 가져오는..
@api_view(['POST'])
def create_user(request):
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    User.objects.create(
        userId = input['userId'],
        userPw = input['userPw']
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
def set_user_beacon(request):
    # 모바일에서 UUID를 받은 경우 -> user의 UUID값을 변경시켜준다.
    # input
    # userId, UUID
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    userS = list(User.objects.filter(userId = input['userId']))
    user = userS[0]
    user.connectedUUID = input['connectedUUID'] # NULL | UUID
    user.save()

