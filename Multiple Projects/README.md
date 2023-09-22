# Gamer.2023
I have some new ideas I want to try out.

## Proposed Changes
Beyond the usual refactoring and coding improvements...

### Process Changes
- Write a couple use cases to formalize the desired behaviors.

### Funtional Changes
- Implement a second board game
- Implement a graphical UI (possibly Maui to show cross-platform support)

### Technical Changes
- Add database support (SQLite files).
- Use a rule engine to validate game play.
- Implement a learning model for automated game play.
-- The current autoamted player finds the available board positions then randomly selects a position to play.
- Use containers for all components except the client.
- Use kubernetes to spin up a cluster with multiple component instances.
- Use Dapr as a sidecar in the container.
- Use a message bus for communication between the client and the managers.
- Add a security model to preserve player data overtime (requires data persistence between exectutions aka DB support).
- Apply versioning schema to support running multiple versions of a given component.  
- All code quality metrics
- Create dependency validation project to enforce the architecture.