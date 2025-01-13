FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Tools
# install zsh and oh-my-zsh
RUN apt update && apt install -y zsh wget git \
  && sh -c "$(wget https://raw.githubusercontent.com/robbyrussell/oh-my-zsh/master/tools/install.sh-O -)" \
  && git clone https://github.com/zsh-users/zsh-autosuggestions ~/.zsh/zsh-autosuggestions \
  && echo "source ~/.zsh/zsh-autosuggestions/zsh-autosuggestions.zsh" >> ~/.zshrc \
  && echo "ZSH_THEME=af-magic" >> ~/.zshrc

WORKDIR /root
COPY . .

ENV CONNECTION_STRING="Temp"

# RUN dotnet restore

# run tests on docker run
ENTRYPOINT ["dotnet", "test"]