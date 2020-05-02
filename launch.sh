#!/bin/sh
s=$(find /app/*.keytab) 2> /dev/null
if [ -z "$s" ]
then
	echo "No kerberos keytab found"
else
	s=${s##*/}
	kinit ${s%.*} -k -t /app/${s%.*}.keytab
	klist
fi
dotnet "S2DbTester.dll"
