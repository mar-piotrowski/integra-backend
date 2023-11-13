# Domain Models

## Register
```
POST /api/integra/v1/account/register
```
```json
{
  "firstname": "",
  "lastname": "",
  "email": "",
  "phone": "",
  "company": {
    "nip": 0,
    "regon": 0,
    "representative": "",
    "location": {
      "street": "",
      "houseNo": "",
      "apartmentNo": "",
      "postalCode": "",
      "city": "",
      "country": "",
      "commune": "",
      "district": "",
      "province": ""
    }
  },
  "consentToTheRODO": true
}
```

## Login
```
POST /api/integra/v1/account/login
```
```json
{
  "email": "",
  "password": ""
}
```

## Reset password
```
PUT /api/integra/v1/account/password
```
```json
{
  "email": ""
}
```

## Change password
```
POST /api/integra/v1/account/{userId}/password
```
```json
{
  "oldPassword": "",
  "newPassword": "",
  "confirmNewPassword": ""
}
```

## CreateEmployee
```
POST /api/integra/v1/employees
```
```json
{
  "firstname": "",
  "lastname": "",
  "secondName": "",
  "motherName": "",
  "fatherName": "",
  "motherLastname": "",
  "fatherLastname": "",
  "birthday": "",
  "birthPlace": "",
  "pesel": "",
  "sex": 0,
  "email": "",
  "idCardNo": "",
  "phoneNo": "",
  "citizenship": "",
  "nip": "",
  "locations": [
    {
      "street": "",
      "houseNo": "",
      "apartmentNo": "",
      "postalCode": "",
      "city": "",
      "country": "",
      "commune": "",
      "district": "",
      "province": ""
    }
  ],
  "bank": {
    "name": "",
    "number": ""
  }
}
```

## GetEmployee
```
GET /api/integra/v1/employees/{employeeId}
```
```json
{
  "id": 1,
  "firstname": "",
  "lastname": "",
  "secondName": "",
  "motherName": "",
  "fatherName": "",
  "motherLastname": "",
  "fatherLastname": "",
  "birthday": "",
  "birthPlace": "",
  "pesel": "",
  "sex": 0,
  "email": "",
  "idCardNo": "",
  "phoneNo": "",
  "citizenship": "",
  "nip": "",
  "locations": [
    {
      "street": "",
      "houseNo": "",
      "apartmentNo": "",
      "postalCode": "",
      "city": "",
      "country": "",
      "commune": "",
      "district": "",
      "province": ""
    }
  ],
  "bank": {
    "name": "",
    "number": ""
  }
}
```

## GetEmployees
```
GET api/integra/v1/employees
```
```json
{
  "employees": [
    {
      "id": 1,
      "firstname": "",
      "lastname": "",
      "secondName": "",
      "motherName": "",
      "fatherName": "",
      "motherLastname": "",
      "fatherLastname": "",
      "birthday": "",
      "birthPlace": "",
      "pesel": "",
      "sex": 0,
      "email": "",
      "idCardNo": "",
      "phoneNo": "",
      "citizenship": "",
      "nip": "",
      "locations": [
        {
          "street": "",
          "houseNo": "",
          "apartmentNo": "",
          "postalCode": "",
          "city": "",
          "country": "",
          "commune": "",
          "district": "",
          "province": ""
        }
      ],
      "bank": {
        "name": "",
        "number": ""
      }
    }
  ]
}
```

## DeleteEmployee
```
POST /api/integra/v1/employees/{employeeId}
```

## CreateEmployeeHolidayLimit
```
POST /api/integra/v1/absence?=limit
```
```json
{
  "userId", "",
  "year": 0,
  "holidayLimitType": 0,
  "description": ""
}
```

## CreateEmployeeAbsence
```
POST /api/integra/v1/absence
```
```json
{
  "userId": "",
  "absenceType": "",
  "startDate": "",
  "endDate": "",
  "description": ""
}
```

## ApproveEmployeeAbsence
```
POST /api/integra/v1/absence/{absenceId}?=approve
```

## DeclineEmployeeAbsence
```
POST /api/integra/v1/absence/{absenceId?=decline
```

## GetContractor
```
GET /api/integra/v1/contractors/{contractorId}
```

## GetContractors
```
GET /api/integra/v1/contractors
```

## CreateContractor
```
POST /api/integra/v1/contractors
```
```json
{
  "companyFullName": "",
  "companyShortName": "",
  "representative": "",
  "nip": "",
  "location": {
    "street": "",
    "houseNo": "",
    "apartmentNo": "",
    "postalCode": "",
    "city": "",
    "country": "",
    "commune": "",
    "district": "",
    "province": ""
  },
  "bank": {
    "name": "",
    "number": ""
  }
}
```

## DeleteContractor
```
POST /api/integra/v1/contractors/{contractorId}
```

## EditContractor
```
PUT /api/integra/v1/contractors/{contractorId}
```
```json
{
  "companyFullName": "",
  "companyShortName": "",
  "representative": "",
  "nip": "",
  "location": {
    "street": "",
    "houseNo": "",
    "apartmentNo": "",
    "postalCode": "",
    "city": "",
    "country": "",
    "commune": "",
    "district": "",
    "province": ""
  },
  "bank": {
    "name": "",
    "number": ""
  }
}
```
