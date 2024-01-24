#include <stdio.h>
#include <stdlib.h>

typedef struct node
{
    int key;
    struct node *next;
} node;

node *head = NULL;
node *tail = NULL;

node *MakeNode(int k)
{
    node *newNode = (node *)malloc(sizeof(node));
    newNode->key = k;
    newNode->next = NULL;
    return newNode;
}

void PushFront(int key)
{
    node *newNode = MakeNode(key);
    newNode->next = head;
    head = newNode;
    if (tail == NULL)
    {
        tail = head;
    }
}

void PopFront()
{
    if (head == NULL)
    {
        printf("Error: List is empty\n");
    }
    else
    {
        node *temp = head;
        head = head->next;
        free(temp);
    }
    if (head == NULL)
    {
        tail = NULL;
    }
}
void PushBack(int k)
{
    node *newNode = MakeNode(k);
    if (tail == NULL)
    {
        tail = newNode;
        head = tail;
    }
    else
    {
        tail->next = newNode;
        tail = newNode;
    }
}
void PopBack()
{
    if (head == NULL)
    {
        printf("Error: List is empty\n");
    }
    if (head == tail)
    {
        head = NULL;
        tail = NULL;
    }
    node *p = head;
    while (p != NULL)
    {
        if (p->next->next == NULL)
        {
            node* tmp=p->next;
            p->next = NULL;
            free(tmp);
            tail = p;
            break;
        }
        p = p->next;
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
node* Find(int key)
{
    node *p = head;
    while (p != NULL)
    {
        if (p->key ==key)
        {
            return p;
        }
        p = p->next;
    }
    return NULL;
}
void AddAfter(node *myNode, int key)
{
    node *newNode = MakeNode(key); 
    newNode->next=myNode->next;
    myNode->next = newNode;
    if (tail == myNode)
    {
        tail = newNode;
    }
}
int main()
{
    PushFront(2);
    PushFront(1);
    PrintList();
    // PopFront();
    // PrintList();
    PushBack(3);
    PrintList();
    // PopBack();
    // PrintList();
    AddAfter(Find(2),-88);
    PrintList();
    return 0;
}
