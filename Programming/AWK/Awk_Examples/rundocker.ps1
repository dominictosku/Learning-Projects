# Define Docker image name
$imageName = "my-awk"

# Path to the Dockerfile directory (assumes Dockerfile is in the current directory)
$dockerfilePath = (Get-Location).Path

# Docker build command
docker build -t $imageName $dockerfilePath

# Define the local directory for the volume mount
$localMountPath = Join-Path -Path $dockerfilePath -ChildPath "src"

# Docker run command
docker run -it --name my-awk -v "$($localMountPath):/dockermount" $imageName

# Note: Remove `-it` and add `-d` for detached mode if running in a script without interactive terminal.
