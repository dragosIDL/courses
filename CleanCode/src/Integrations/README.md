Integrations is where we define implementation for the Interfaces defined in the Domain


Integrations can either be implemented as a single or many projects depending on the level of complexity of your app.

This is where you define your Integration specific models, that might look totally different than your representation in the Domain.
Ideally the model defined in the Domain is much more stable than the one defined in the Integration as any Integration model needs to be transformed into a model the Domain can interpret