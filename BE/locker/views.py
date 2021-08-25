from django.db.models import Q

from user.models import *
from django.http.response import HttpResponse
from rest_framework.response import Response
from rest_framework.decorators import api_view

from .serializers import *

## 가져오는..

@api_view(['POST'])
def get_vacant_lockerS_stationIdx(request):
    # input
    # - stationName (required)
    stationName = request.data['stationName']
    OccupiedLocker_numberS = list(
        OccupiedLocker.objects
        .filter(stationName = stationName).value('number')
    )
    vacantLockerS = list(
        Locker.objects
        .filter(Q(stationName = stationName) & ~Q(number__in = OccupiedLocker_numberS))
    )
    serializer = Locker(vacantLockerS, many = True)
    print("VACANT LOCKER IN "+stationName+" : ")
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
    input = request.data
    userS = list(User.objects.filter(userId = input['trusterId']))
    user = userS[0]
    autoPayment = user.autoPayment

    OccupiedLocker.objects.create(
        lockerIdx = input['lockerIdx'],
        password = input['password'],
        title = input['title'],
        info = input['info'],
        isOpen = input['isOpen'],
        trusterId = input['trusterId'],
        isPaid = autoPayment
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

    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = request.data['idx']))
    occupiedLocker = occupiedLockerS[0]
    input = request.data

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
    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = request.data['idx']))
    occupiedLocker = occupiedLockerS[0]
    serializer = serializers.OccupiedLockerSerializer(occupiedLocker)
    occupiedLocker.delete()
    return Response(serializer.data)
@api_view(['POST'])
def get_all_lockers_onStation(request):
    # input
    # - idx (required)
    req = request.data
    lockerS = Locker.objects.filter(UUID = req['UUID'])
    serializer = serializers.LockerSerializer(lockerS)
    return Response(serializer.data)
@api_view(['POST'])
def get_all_occupiedLockers_onStation(request):
    # input
    # - idx (required)
    req = request.data
    occupiedLockerS = OccupiedLocker.objects.filter(lockerId__in = req['lockerIdS'])
    serializer = serializers.OcupiedLockerSerializer(occupiedLockerS)
    return Response(serializer.data)
