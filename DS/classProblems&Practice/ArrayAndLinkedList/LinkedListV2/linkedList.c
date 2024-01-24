#include <stdio.h>
#include <stdlib.h>
#include "linkedList.h"

typedef struct _node
{
    int data;
    struct _node *next;
} node;

node *makeNode(int data)
{
    node *new_node = (node *)malloc(sizeof(node));
    new_node->data = data;
    new_node->next = NULL;
    return new_node;
}
node *makeList()
{
    node *head = NULL;
    node *last = NULL;
    for (int i = 0; i < 10; i++)
    {
        node *newNode = makeNode(i);
        if (head == NULL)
        {
            head = newNode;
        }
        if (last != NULL)
        {
            last->next = newNode;
        }
        last = newNode;
    }
    return head;
}
node *pushFront(node *head, int data)
{
    node *newNode = makeNode(data);
    newNode->next=head;
    return newNode;
}
node *pushBack(node *head, int data)
{
    node *newNode = makeNode(data);
    while (head!=NULL)
    {
        if(head->next==NULL)
        {
            head->next=newNode;
            break;
        }
        head=head->next;
    }
    
    newNode->next=head;
    return newNode;
}
int main(int argc, char const *argv[])
{
    // node *n1 = makeNode(1);
    // node *n2 = makeNode(2);
    // n1->next = n2;
    // printf("%d\n", n1->data);
    // printf("%d\n", n1->next->data);
    node *n = makeList();
    printList(n);
    // n=pushFront(n,-1);
    n=pushBack(n,10);
    printList(n);

    return 0;
}
void printList(node *n)
{
    while (n != NULL)
    {
        printf("%d -> ", n->data);
        n = n->next;
    }
    printf("\n");
}
