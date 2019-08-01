import { AnimalPhoto } from './AnimalPhoto';

export class Animals {
    ID: number;
    Type: string;
    Name: string;
    Gender: string;
    age: number;
    status: boolean;
    MarriedCount: number;
    Description: string;
    SonsCount: number;
    MarriedSalary: number;
    AvailableMarried: boolean;
    AvailableForBill: boolean;
    CategoryID: number;
    CategoryName: string;
    animalPhoto: AnimalPhoto[];
}
