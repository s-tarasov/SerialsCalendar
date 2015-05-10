#!/bin/bash
cp /configs/appSettings.json /app/Calendar.Web/

dnx . --configuration=Debug kestrel
