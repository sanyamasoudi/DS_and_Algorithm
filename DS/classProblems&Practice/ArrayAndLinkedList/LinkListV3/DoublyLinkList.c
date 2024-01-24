#include <stdio.h>
#include <stdlib.h>
typedef struct node
{
    int key;
    struct node *next;
    struct node *prev;
} node;

node *head = NULL;
node *tail = NULL;

node *MakeNode(int k)
{
    node *newNode = (node *)malloc(sizeof(node));
    newNode->key = k;
    newNode->next = NULL;
    newNode->prev = NULL;
}
void PushBack(int key)
{
    node *newNode = MakeNode(key);
    if (tail == NULL)
    {
        tail = newNode;
        head = newNode;
        newNode->prev = NULL;
    }
    else
    {
        newNode->prev = tail;
        tail->next = newNode;
        tail = newNode;
    }
}
void PopBack()
{
    if (head == NULL)
    {
        printf("List Is Empty!\n");
    }
    else if (head == tail)
    {
        head = NULL;
        tail = NULL;
    }
    else
    {
        tail = tail->prev;
        tail->next = NULL;
    }
}
void PrintList()
{
    node *p = head;
    while (p != NULL)
    {
        printf("%d", p->key);
        if (p->next != NULL)
        {
            printf("->");
        }
        p = p->next;
    }
    printf("\n");
}
node *Find(int k)
{
    node *p = head;
    while (p != NULL)
    {
        if (p->key == k)
        {
            return p;
        }
        p = p->next;
    }
    return NULL;
}
void AddAfter(node *n, int key)
{
    node *newNode = MakeNode(key);
    newNode->prev = n;
    newNode->next = n->next;
    n->next = newNode;
    if (newNode->next != NULL)
    {
        newNode->next->prev = newNode;
    }
    if (n == tail)
    {
        tail = newNode;
    }
}
void AddBefore(node *n, int key)
{
    node *newNode = MakeNode(key);
    newNode->next = n;
    newNode->prev = n->prev;
    n->prev = newNode;
    if (newNode->prev != NULL)
    {
        newNode->prev->next = newNode;
    }
    if (n == head)
    {
        head = newNode;
    }
}
int main()
{
    PushBack(1);
    PushBack(2);
    PushBack(3);
    PrintList();
    AddAfter(Find(2), -88);
    PrintList();
    // PopBack();
    // PrintList();
    // PopBack();
    // PrintList();
    // PopBack();
    // PrintList();
    // PopBack();
    return 0;
}
