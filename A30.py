class Logger:
    _instance = None

    def __new__(cls):
        if cls._instance is None:
            cls._instance = super(Logger, cls).__new__(cls)
            cls._instance.logs = []
        return cls._instance

    def log(self, message):
        self.logs.append(message)
        print(f"LOG: {message}")


class BankAccount:
    def __init__(self, account_number, balance=0):
        self.account_number = account_number
        self.balance = balance
        self.logger = Logger()

    def deposit(self, amount):
        self.balance += amount
        self.logger.log(f"Deposited {amount} to account {self.account_number}. New balance: {self.balance}")

    def withdraw(self, amount):
        if amount > self.balance:
            self.logger.log(f"Attempted to withdraw {amount} from account {self.account_number} - Insufficient funds")
            raise ValueError("Insufficient funds")
        self.balance -= amount
        self.logger.log(f"Withdrew {amount} from account {self.account_number}. New balance: {self.balance}")


# Приклад використання
if __name__ == "__main__":
    acc = BankAccount("UA1234567890", 1000)
    acc.deposit(500)

    try:
        acc.withdraw(2000)
    except ValueError as e:
        print(e)

    acc.withdraw(300)

    # Перевірка логів
    print("\nTransaction log:")
    for log_entry in Logger().logs:
        print(log_entry)
