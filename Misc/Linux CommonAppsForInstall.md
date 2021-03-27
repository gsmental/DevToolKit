## https://snapcraft.io/ or (snap install skype postman)
* snap install skype --classic
* snap install postman
* snap install filezilla
* snap install vlc
* snap install opera
* snap install gimp
* snap install telegram-desktop
* snap install node --classic
* snap install thunderbird
* snap install rambox -- all ine one app for many social apps like whatsapp,skype,slack,gmail,dropbox
* snap install zoom-client


## sodu apt install 
* sudo apt install git
* sudo apt install gnome-tweaks


## Terminal (sudo dpkg -i package_file.deb)
* AnyDesk https://anydesk.com/en/downloads/linux
* Google Chrome https://www.google.com/chrome/index.html
* FreeDownloadManager FDM https://www.freedownloadmanager.org/download-fdm-for-linux.htm
* Azure Data Studio https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio 
* VSCode https://code.visualstudio.com/download#  **(dont use snap)**
* DBeaver https://dbeaver.io/download/


## Terminal (in Other mode)
##### git https://git-scm.com/downloads
  * apt-get install git
  * add-apt-repository ppa:git-core/ppa
  * apt update; apt install git
##### JDK/JRE
 *  type java in terminal, if not install it will give you complete instalation text, copy and paste in terminal

  
  

## Wine
* winamp
* Microsoft Office 2007
* SQL Backup and FTP
* Reduce PDF Size
* TTFA PDF Page Counter
 

## Dotnet SDK Installation
#### Ubuntu Installation 20.4 https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-3.1


## usefull app list
https://itsfoss.com/best-ubuntu-apps/


## How to Install Mono on Ubuntu 20.04 | 18.04
* https://www.mono-project.com/download/stable/#download-lin
* https://linuxize.com/post/how-to-install-mono-on-ubuntu-20-04/
* sudo apt update
* sudo apt install dirmngr gnupg apt-transport-https ca-certificates software-properties-common
* sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
* sudo apt-add-repository 'deb https://download.mono-project.com/repo/ubuntu stable-bionic main'
* sudo apt install mono-complete 
* mono --version
* sudo apt install monodevelop
* in case of error during build, delete bin/obj from all projects. in nutshell, it add nuget and other paths according to OS
