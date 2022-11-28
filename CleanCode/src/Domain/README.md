The domain is a standalone project, it can have references to other packages, but to no other projects in our application.

The Domain project contains all our code independent of explicit implementations

Ideally the domain code can remain unaltered, while allowing us to swap an Integration for another one if we so desire. This is done through the use of Interfaces

The Domain should not interact explicitly with any Integrations - unless they are core of the process, to such a level that it should not be abstracted. Such an example could be EntityFramework where there is a tight integration between the database and the models created.
An abstraction level can be added between them, but that level is painful to manage.
