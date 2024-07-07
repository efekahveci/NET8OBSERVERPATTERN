# Observer Pattern Example

This repository contains an example of the Observer design pattern implemented in C#. It demonstrates how observers can receive notifications about updates to product prices. 

## How it Works

The `Product` class acts as the subject being observed, while the `Amazon` class manages observers (implementing `IObserver`). Observers are registered, unregistered, and notified of changes in product prices.

## Usage

1. Create instances of `Product` and `ProductObserver`.
2. Register observers using `Amazon.Register(observer, product)`.
3. Notify observers of changes using `Amazon.Notify(updatedProduct)`.

Feel free to explore the code to understand more about how the Observer pattern is applied in this scenario.
