from django.db import models

class User(models.Model):
    phoneNumber = models.TextField()
    password = models.TextField()
    
    autoPayment = models.BooleanField()

    connectedUUID = models.TextField(null=True,blank=True) # locker.models.Locker.UUID와 같은 field type