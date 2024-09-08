![image](https://github.com/user-attachments/assets/0283746b-6880-4dab-a376-7861bda1d027)
*** 
## Generic PassThru Diagnostic Software
General purpose diagnostic software that allows you to control individual diagnostic services. Have not seen any open source generic diagnostic software for J2534 devices. Currently for use on vehicles with ECUs on a typical High Speed CAN and Medium Speed CAN, aiming for it to work with Ford, Mazda, JLR, Volvo and anything OBD2 compliant.
![image](https://github.com/user-attachments/assets/c43cbd55-5c05-4653-8ea9-c111af294497)

## Current Functionality 
- Diagnosfic Session Control
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

## J2534 Interface
This implementation currently only works with an OBDXPro FT J2534 interface(https://obdxpro.com). Hoping to troubleshoot it such that it is compliant with all J2534 interfaces, ie VCM2, VCM3, Tactrix Openport, Mongoose Pro. Feel free to fork and modify it to work with your devices.

