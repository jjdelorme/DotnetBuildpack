# DotnetBuildpack
Demonstrates using [cloud native build packs](https://buildpacks.io/docs/tools/pack/) with the [Google builder](https://cloud.google.com/blog/products/containers-kubernetes/google-cloud-now-supports-buildpacks) to automatically create a container image from source.

Download the [pack cli](https://buildpacks.io/docs/tools/pack/#pack-cli) and execute this: 

```bash
pack build my-app --builder gcr.io/buildpacks/builder
```

There is a dotnet core 3.1 build pack available.  

## Build using Google Cloud Build
gcloud builds submit --pack=image=gcr.io/$PROJECT_ID/dotnetbuildpack
