![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
![image](https://github.com/user-attachments/assets/0283746b-6880-4dab-a376-7861bda1d027)
*** 

<a href="https://testerpresent.com.au/"><img src="https://img.shields.io/badge/Tester Present -Specialist Automotive Solutions-blue" /></a>

## Generic PassThru Diagnostic Software
General purpose diagnostic software that allows you to control individual diagnostic services. Have not seen any open source generic diagnostic software for J2534 devices so I thought I would make some. Currently for use on vehicles with ECUs on a typical High Speed CAN and Medium Speed CAN, aiming for it to work with Ford, Mazda, JLR, Volvo and anything OBD2 compliant. Allows you to set the ECU RX & TX Address (ie 7E0, 7E8 for a Powertrain Control Module) and connect to that ECU, amd perform basic diagnostic functions using both KWP2000 type protocol or UDS protocol. This is a work in progress... 


    

![image](https://github.com/user-attachments/assets/3f2eaa98-8e04-45a7-8b6a-b19dd6c526fd)
![image](https://github.com/user-attachments/assets/c43cbd55-5c05-4653-8ea9-c111af294497)
![image](https://github.com/user-attachments/assets/64f3f9bd-a5d5-4e22-a245-30f360df8ab2)


## Current Functionality (using KWP2000, UDS)
- Diagnostic Session Control
- ECU Reset
- Tester Present
- Security Access
- Control DTC Setting
- Bruteforce Security Access

## Planned Functionality 
- OBD2 Implementation
- Read and Clear Diagnostic Trouble Codes
- Enumerate all online ECUs
- VIN Decoder
- CAN Sniffer
- PID Lookup tool via service 0x22


<img align="right" src="https://testerpresent.com.au/wp-content/uploads/2024/03/EDR@2x-1.png" height="20%" width="20%"/>

## J2534 Interface
This implementation currently only works with an OBDXPro FT J2534 interface(https://obdxpro.com). Hoping to troubleshoot it such that it is compliant with all J2534 interfaces, ie VCM2, VCM3, Tactrix Openport, Mongoose Pro. Feel free to fork and modify it to work with your devices.

## Executable Download
https://mega.nz/file/IOtFTRra#fx2Hv2PqSp8vAag8wl4Iwv1nZYgpZof4Q94DAbdECOc
![image](https://github.com/user-attachments/assets/5d286541-9565-4ab7-8677-83823695f371)



      
![image](https://user-images.githubusercontent.com/57064943/163714778-8598c24a-6ae2-49f6-ba4c-42de94dfa025.png)
