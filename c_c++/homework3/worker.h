#ifndef WORKER_H
#define WORKER_H

#include "employee.h"

class Worker : public Employee
{
private:
    int workHours;	// 月工作时间
public:
    Worker();
    Worker(char *n , int a, int w, char s, int m, int g, int t, int h);
    void setWorkHours(int h);
	int getWorkHours();
	void print();
};

#endif // WORKER_H
