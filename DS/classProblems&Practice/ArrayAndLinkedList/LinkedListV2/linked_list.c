#include<stdio.h>
#include<stdlib.h>

typedef struct _node
{
    int key;
    struct _node *next;
}node;

node* make_node(int key)
{
    //not implemented
    node *new_node = (node*) malloc(sizeof(node));
    new_node->key=key;
    new_node->next=NULL;

    return new_node;
}

node* make_list()
{
    node *head= NULL;
    node *last = NULL;

    for(int i=0; i<10; i++)
    {
        node *new_node=make_node(i);
        if (head==NULL)
        {
            head=new_node;
        }
        if(last!=NULL)
        {
            last->next=new_node;
        }
        last=new_node;
    }

    return head;
}


node* push_front(node *head, int key)
{
    //not implemented
    node *new_node=make_node(key);
    new_node->next=head;

    return new_node;
}

void push_back(node *head, int key)
{
    //not implemented
    node *new_node = make_node(key);

    while (head != NULL)
    {
        if (head->next == NULL)
        {
            head->next=new_node;
            break;
        }

        head = head->next;
    }
    
}

node* pop_front(node *head)
{
    //not implemented
    node* tmp = head;
    head=head->next;
    free(tmp);
    return head;
}

void pop_back(node *head)
{
    //not implemented
}

node* find(node *head, int key)
{
    //not implemented

    while (head!=NULL)
    {
        if(head->key==key)
        {
            return head;
        }

        head = head->next;
    }

    return NULL;
    
}

void print_list(node * head)
{
    //not implemented
    while (head!=NULL)
    {
        printf("%d ->", head->key);
        head=head->next;
    }
    printf("\n");
    
}

node* delete_node(node *head, node *del_node)
{
    //not implemented
    if (del_node==head)
        return pop_front(head);

    node *p = head;
    while (p->next != NULL)
    {
        if(p->next == del_node)
        {
            p->next = del_node->next;
            free(del_node);
            break;
        }
        p = p->next;
    }
    return head;
    
}

int main()
{
    node *head=make_list();
    print_list(head);
    head = push_front(head, 11);
    print_list(head);
    push_back(head, 12);
    print_list(head);
    head = pop_front(head);
    print_list(head);
    node *p = find(head, 12);
    printf("%d %x \n", p->key, p);
    head = delete_node(head, p);
    print_list(head);
    return 0; 
}