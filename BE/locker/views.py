from django.db.models import Q

from user.models import *
from django.http.response import HttpResponse
from rest_framework.response import Response
from rest_framework.decorators import api_view

from .serializers import *
import json
## 가져오는..

@api_view(['POST'])
def get_occupiedLockerS_stationUUID(request):
    # input
    # - stationName (required)
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    stationUUID = input['stationUUID']

    lockerS = list(
        Locker.objects
        .filter(stationUUID = stationUUID).values_list('idx')
    )
    occupiedLockerS = list(
        OccupiedLocker.objects.filter(lockerIdx__in = lockerS)
    )
    serializer = OccupiedLocker(occupiedLockerS, many = True)
    print("VACANT LOCKER IN UUID:"+stationUUID+" => ")
    print(serializer.data)
    return Response(serializer.data)
@api_view(['POST'])
def create_occupiedLocker(request):
    # input
    # - lockerIdx (required)
    # - password (required)
    # - title (required)
    # - info (required)
    # - isOpen (required)
    # - trusterId (required)
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    # userS = list(User.objects.filter(userId = input['trusterId']))
    # user = userS[0]
    # autoPayment = user.autoPayment

    OccupiedLocker.objects.create(
        lockerIdx = input['lockerIdx'],
        password = input['password'],
        title = input['title'],
        info = input['info'],
        isOpen = input['isOpen'],
        trusterId = input['trusterId']
    )
    return HttpResponse('CREATE LOCKER USING')
@api_view(['POST'])
def update_occupiedLocker(request):
    # input
    # - idx (required)
    # - password
    # - title
    # - info
    # - isOpen
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = input['idx']))
    occupiedLocker = occupiedLockerS[0]


    if 'password' in input:
        occupiedLocker.password = input['password']
    if 'title' in input:
        occupiedLocker.title = input['title']
    if 'info' in input:
        occupiedLocker.info = input['info']
    if 'isOpen' in input:
        occupiedLocker.title = input['isOpen']
    if 'isPaid' in input:
        occupiedLocker.isPaid = input['isPaid']

    return HttpResponse('UPDATE LOCKER USING')
@api_view(['POST'])
def delete_occupiedLocker(request):
    # input
    # - idx (required)
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = input['idx']))
    occupiedLocker = occupiedLockerS[0]
    serializer = serializers.OccupiedLockerSerializer(occupiedLocker)
    occupiedLocker.delete()
    return Response(serializer.data)
@api_view(['POST'])
def get_all_lockerS_onStation(request):
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    lockerS = Locker.objects.filter(stationUUID = input['stationUUID'])
    serializer = serializers.LockerSerializer(lockerS)
    return Response(serializer.data)
@api_view(['POST'])
def get_all_occupiedLockerS_onStation(request):
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    occupiedLockerS = OccupiedLocker.objects.filter(lockerId__in = input['lockerIdS'])
    serializer = serializers.OcupiedLockerSerializer(occupiedLockerS)
    return Response(serializer.data)
