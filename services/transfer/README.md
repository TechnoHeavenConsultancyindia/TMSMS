# TMSMS.TransferService

If you check the *Enable integration* option when creating the microservice, the necessary configurations are made automatically, so no manual configuration is needed. For more information, refer to the [Adding New Microservices](https://abp.io/docs/latest/solution-templates/microservice/adding-new-microservices) document.


## Docker Configuration for Prometheus

If you want to monitor the new microservice with Prometheus when you debug the solution, you should add the new microservice to the `prometheus.yml` file in the `etc/docker/prometheus` folder. You can copy the configurations from the existing microservices and modify them according to the new microservice. Below is an example of the `prometheus.yml` file for the `Product` microservice.

```diff
  - job_name: 'authserver'
    scheme: http
    metrics_path: 'metrics'
    static_configs:
    - targets: ['host.docker.internal:***']
    ...
+ - job_name: 'transfer'
+   scheme: http
+   metrics_path: 'metrics'
+   static_configs:
+   - targets: ['host.docker.internal:44370']
```

## Developing the UI for the New Microservice

After adding the new microservice to the solution, you can develop the UI for the new microservice. For .NET applications, you can add the *TMSMS.Microservicename.Contracts* package to the UI application(s) to access the services provided by the new microservice. Afterwards, you can use the [generate-proxy](https://abp.io/docs/latest/cli#generate-proxy) command to generate the proxy classes for the new microservice.

```bash
abp generate-proxy -t csharp -url http://localhost:44370/ -m transfer --without-contracts
```

Next, start creating *Pages* and *Components* for the new microservice in the UI application(s). Similarly, if you have an Angular application, you can use the [generate-proxy](https://abp.io/docs/latest/cli#generate-proxy) command to generate the proxy classes for the new microservice and start developing the UI.

```bash
abp generate-proxy -t ng -url http://localhost:44370/ -m transfer
```