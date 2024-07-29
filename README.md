## Compose
```sh
docker compose -f docker-compose.yml -f development.yml up -d
```

## Run Unit Tests
```sh
dotnet test --filter "Tests.Units" \
  --results-directory ./tests/reports/ \
  --logger "trx;LogFileName=unit-tests.trx"
```

## Run Integration Tests
```sh
dotnet test --filter "Tests.Integrations" \
  /p:CollectCoverage=true \
  /p:CoverletOutputFormat=cobertura \
  /p:CoverletOutput=./reports/code-coverage.xml
```