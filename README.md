
# Academy Management System
A console-based Academy Management System built with C# and .NET 8 following Clean Architecture and SOLID Principles.

## Key Features
- Student Management: Register students with unique ID validation, view all registered students, and delete students.
- Course Management: Add courses with unique ID validation, view available courses, and filter courses dynamically (by maximum price or maximum hours).
- Enrollment System: Enroll students in courses cleanly, with validation preventing duplicate enrollments.
- Certificates System: Generate and view student completion certificates.

## Advanced C# & OOP Concepts Applied

### 1. Object-Oriented Programming (OOP) Core
- Encapsulation & Model Initialization: Protected state via auto-properties across models (`Student`, `Course`, `Enrollment`, `Certificate`) with fallback initializations ensuring zero `NullReferenceException` risks.
- Abstraction: Defined explicit interface contracts (`IStudentService`, `ICourseService`, etc.) to separate requirements from execution logic.
- Inheritance & Composition: Leveraged "is-a" class inheritance (`Student` inheriting from `Person`) alongside "has-a" object composition within models (such as `Enrollment` holding references to `Student` and `Course`).
- Polymorphism: Allowed multiple service implementations to work seamlessly through shared abstractions.

### 2. SOLID Principles & Clean Architecture
- Single Responsibility Principle (SRP): Clear separation of concerns between data models (`Models`), business logic (`Services`), UI formatting (`Extensions`), and input handling (`Helpers`).
- Open/Closed Principle (OCP): Extended features like dynamic predicate course filtering without altering core stable service logic.
- Liskov Substitution Principle (LSP): Ensured concrete service classes serve as fully valid substitutes for their respective interface contracts.
- Interface Segregation Principle (ISP): Designed small, focused, and purpose-driven interfaces rather than large bloated contracts.
- Dependency Inversion Principle (DIP): High-level modules and `Program.cs` depend on abstractions rather than concrete implementations.

### 3. C# Language & Framework Capabilities
- Extension Methods: Clean, reusable formatting and console rendering for collections (`PrintCourses`, `PrintStudents`, `PrintCertificates`).
- LINQ & Lambdas: Functional querying, filtering, and conditional checks (`.FirstOrDefault()`, `.Where()`, `.Any()`).
- Delegates & Predicates: Dynamic filtering logic using `Func<Course, bool>`.
- Nullable Reference Types (NRT): Safe null handling (`Student?`, `Course?`) preventing runtime crashes.
- Robust Exception-Free Input Handling: Centralized CLI input processing with type safety and loop validations via `InputHelpers`.

## Versioning
- Release Tag: `V1.0.0`