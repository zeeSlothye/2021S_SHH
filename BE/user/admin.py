from user.models import User;
from rest_framework.decorators import api_view
from .models import *
from django.contrib import admin

# Register your models here.
admin.site.register([User])