NUM_NODES = 10
WORLD_SIZE = 1000

go: go.go
	go build go.go

dmd: d.d
	dmd d.d -ofdmdd -O -release -inline

graphbuilder: mkgraph.go
	go build mkgraph.go

graph: graphbuilder
	./mkgraph -places=$(NUM_NODES) -worldsize=$(WORLD_SIZE) > agraph
