/*
Author: Jay Patel, 000881881
Date: 11/11/2023
Purpose: Lab 4 Part A
I, Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

using System;
using Lab4A;
using System.Collections;

namespace Lab4A
{
    // Define the Employee class
    public class Employee
    {
        // Properties to store employee information
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public double Hours { get; set; }

        // Constructor to initialize an Employee object
        public Employee(string name, int number, decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;
        }

        /// <summary>
        /// Calculates the gross pay for the employee based on hours worked and hourly rate.
        /// </summary>
        /// <returns>The calculated gross pay.</returns>
        public decimal GetGross()
        {
            decimal regularPay;
            decimal overtimePay;
            double overtimeHours;

            if (Hours <= 40)
            {
                return (decimal)Hours * Rate;
            }
            else
            {
                regularPay = 40 * Rate;
                overtimeHours = Hours - 40;
                overtimePay = (decimal)overtimeHours * (Rate * 1.5m);
                return regularPay + overtimePay;
            }
        }

        /// <summary>
        /// Compares the current employee with another employee for natural sorting (by name).
        /// </summary>
        /// <param name="other">The other employee to compare.</param>
        /// <returns>An integer that indicates the relative order of the employees.</returns>
        public int CompareTo(Employee other)
        {
            // Assuming you want to sort by name
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}


