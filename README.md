![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
![image](https://github.com/user-attachments/assets/0283746b-6880-4dab-a376-7861bda1d027)
*** 

<a href="https://testerpresent.com.au/"><img src="https://img.shields.io/badge/Tester Present -Specialist Automotive Solutions-blue" /></a>

## Generic PassThru Diagnostic Software
General purpose diagnostic software that allows you to control individual diagnostic services. Have not seen any open source generic diagnostic software for J2534 devices so I thought I would make some. Currently for use on vehicles with ECUs on a typical High Speed CAN and Medium Speed CAN, aiming for it to work with Ford, Mazda, JLR, Volvo and anything OBD2 compliant. Allows you to set the ECU RX & TX Address (ie 7E0, 7E8 for a Powertrain Control Module) and connect to that ECU, and perform basic diagnostic functions using both KWP2000 protocol or UDS protocol. This is a work in progress... 

## Current Functionality (using KWP2000, UDS)
- Diagnostic Session Control
- ECU Reset
- Tester Present
- Security Access
- Control DTC Setting
- Bruteforce Security Access
- OBD2 Implementation
- CAN Sniffer
- VIN Decoder

    

![image](https://github.com/user-attachments/assets/c43cbd55-5c05-4653-8ea9-c111af294497)
![image](https://github.com/user-attachments/assets/d1ea71cb-21b5-47fb-aeef-4032bd605bdb)
![image](https://github.com/user-attachments/assets/ba8fb23b-3de2-4275-933c-e7bffbb3df7b)
![image](https://github.com/user-attachments/assets/1543b81b-6b83-4c1a-8391-e8cda4de3e17)





## Planned Functionality 

- Read and Clear Diagnostic Trouble Codes
- Enumerate all online ECUs
- PID Lookup tool via service 0x22


<img align="right" src="https://testerpresent.com.au/wp-content/uploads/2024/03/EDR@2x-1.png" height="20%" width="20%"/>

## J2534 Interface
This implementation currently only works with an OBDXPro FT J2534 interface(https://obdxpro.com). Hoping to troubleshoot it such that it is compliant with all J2534 interfaces, ie VCM2, VCM3, Tactrix Openport, Mongoose Pro. Feel free to fork and modify it to work with your devices.

## Executable Download
https://mega.nz/file/8P8kFLjb#k7rp6s0qEAtiGq2ecEcXoxE9P0Xromfc8elWgNvsRZA
![image](https://github.com/user-attachments/assets/5d286541-9565-4ab7-8677-83823695f371)
![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
