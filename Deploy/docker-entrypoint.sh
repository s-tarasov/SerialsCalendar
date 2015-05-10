#!/bin/bash
cp /configs/appSettings.json /app/Calendar.Web/

k --configuration=Release kestrel
